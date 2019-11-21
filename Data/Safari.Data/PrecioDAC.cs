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
     public partial class PrecioDAC : DataAccessComponent, IRepository<Precio>
    {
        public Precio Create(Precio Precio)
        {
            const string SQL_STATEMENT = "INSERT INTO Precio ([TipoServicioId],[FechaDesde],[FechaHasta],[Valor]) VALUES(@TipoServicioId,@FechaDesde,@FechaHasta,@Valor);";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, Precio.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.AnsiString, Precio.FechaDesde);
                db.AddInParameter(cmd, "@FechaHasta", DbType.AnsiString, Precio.FechaHasta);
                db.AddInParameter(cmd, "@Valor", DbType.AnsiString, Precio.Valor);
                Precio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            return Precio;
        }

        public List<Precio> Read()
        {
            const string SQL_STATEMENT = "SELECT [TipoServicioId],[FechaDesde],[FechaHasta],[Valor] FROM Precio ";

            List<Precio> result = new List<Precio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Precio Precio = loadprecio(dr);
                        result.Add(Precio);
                    }
                }
            }
            return result;
        }

        public Precio ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [TipoServicioId],[FechaDesde],[FechaHasta],[Valor] FROM Precio WHERE [TipoServicioId]=@TipoServicioId ";
            Precio Precio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Precio = loadprecio(dr);
                    }
                }
            }
            return Precio;
        }

        public void Update(Precio Precio)
        {
            const string SQL_STATEMENT = "UPDATE Precio SET [FechaDesde]= @FechaDesde,[FechaHasta] = @FechaHasta,[Valor] = @Valor WHERE [TipoServicioId]= @TipoServicioId ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, Precio.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.Int32, Precio.FechaDesde);
                db.AddInParameter(cmd, "@FechaHasta", DbType.AnsiString, Precio.FechaHasta);
                db.AddInParameter(cmd, "@Valor", DbType.AnsiString, Precio.Valor);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Precio WHERE [TipoServicioId]= @TipoServicioId ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Precio loadprecio(IDataReader dr)
        {
            Precio Precio = new Precio();
            Precio.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            Precio.FechaHasta = GetDataValue<DateTime>(dr, "FechaHasta");
            Precio.FechaDesde = GetDataValue<DateTime>(dr, "FechaDesde");
            Precio.Valor = GetDataValue<decimal>(dr, "Valor");
            return Precio;
        }
    }
}
