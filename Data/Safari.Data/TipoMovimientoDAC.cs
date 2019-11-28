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
    public partial class TipoMovimientoDAC : DataAccessComponent, IRepository<TipoMovimiento>
    {
        public TipoMovimiento Create(TipoMovimiento entity)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoMovimiento ([Nombre],[Multiplicador]) VALUES(@Nombre,@Multiplicador);";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Boolean, entity.Multiplicador);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoMovimiento WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<TipoMovimiento> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Multiplicador] FROM TipoMovimiento ";

            List<TipoMovimiento> result = new List<TipoMovimiento>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoMovimiento TipoMovimiento = Loadtipomovimiento(dr);
                        result.Add(TipoMovimiento);
                    }
                }
            }
            return result;
        }

        public TipoMovimiento ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Multiplicador] FROM TipoMovimiento WHERE [Id]=@Id ";
            TipoMovimiento TipoMovimiento = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        TipoMovimiento = Loadtipomovimiento(dr);
                    }
                }
            }
            return TipoMovimiento;
        }

        public void Update(TipoMovimiento entity)
        {
            const string SQL_STATEMENT = "UPDATE TipoMovimiento SET [Nombre]= @Nombre, [Multiplicador] = @Multiplicador WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Boolean, entity.Multiplicador);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private TipoMovimiento Loadtipomovimiento(IDataReader dr)
        {
            TipoMovimiento TipoMovimiento = new TipoMovimiento();
            TipoMovimiento.Id = GetDataValue<int>(dr, "Id");
            TipoMovimiento.Nombre = GetDataValue<string>(dr, "Nombre");
            TipoMovimiento.Multiplicador = GetDataValue<Int16>(dr, "Multiplicador");
            return TipoMovimiento;
        }
    }

    
}

