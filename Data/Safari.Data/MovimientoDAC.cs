using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public partial class MovimientoDAC : DataAccessComponent, IRepository<Movimiento>
    {
        public Movimiento Create(Movimiento movimiento)
        {
            const string SQL_STATEMENT = "INSERT INTO Movimiento ([Fecha],[Valor],[ClienteId],[TipoMovimientoId]) VALUES(@Fecha,@Valor,@ClienteId,@TipoMovimientoId); SELECT SCOPE_IDENTITY();";
            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, movimiento.Fecha);
                    db.AddInParameter(cmd, "@Valor", DbType.AnsiString, movimiento.Valor);
                    db.AddInParameter(cmd, "@ClienteId", DbType.AnsiString, movimiento.ClienteId);
                    db.AddInParameter(cmd, "@TipoMovimientoId", DbType.AnsiString, movimiento.TipoMovimientoId);
                    movimiento.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return movimiento;

        }

        public List<Movimiento> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id],[Fecha],[Valor],[ClienteId],[TipoMovimientoId] FROM Movimiento ";

            List<Movimiento> result = new List<Movimiento>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Movimiento movimiento = LoadMovimiento(dr);
                        result.Add(movimiento);
                    }
                }
            }
            return result;
        }

        public Movimiento ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Fecha],[Valor],[ClienteId],[TipoMovimientoId] FROM Movimiento WHERE [Id]=@Id ";
            Movimiento movimiento = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        movimiento = LoadMovimiento(dr);
                    }
                }
            }
            return movimiento;
        }

        public void Update(Movimiento movimiento)
        {
            const string SQL_STATEMENT = "UPDATE Movimiento SET [Fecha] = @Fecha,[Valor] = @Valor,[ClienteId] = @ClienteId,[TipoMovimientoId] = @TipoMovimientoId WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, movimiento.Fecha);
                db.AddInParameter(cmd, "@Valor", DbType.AnsiString, movimiento.Valor);
                db.AddInParameter(cmd, "@ClienteId", DbType.AnsiString, movimiento.ClienteId);
                db.AddInParameter(cmd, "@TipoMovimientoId", DbType.AnsiString, movimiento.TipoMovimientoId);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Movimiento WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Movimiento LoadMovimiento(IDataReader dr)
        {
            Movimiento movimiento = new Movimiento();
            movimiento.Id = GetDataValue<int>(dr, "Id");
            movimiento.Valor = GetDataValue<decimal>(dr, "Valor");
            movimiento.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            movimiento.ClienteId = GetDataValue<int>(dr, "ClienteId");
            movimiento.TipoMovimientoId = GetDataValue<int>(dr, "TipoMovimientoId");
            return movimiento;
        }
    }
}
