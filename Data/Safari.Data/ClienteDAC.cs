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
    public partial class ClienteDAC : DataAccessComponent, IRepository<Cliente>
    {
        public Cliente Create(Cliente cliente)
        {
            const string SQL_STATEMENT = "INSERT INTO Cliente ([Nombre],[Apellido],[Email],[Telefono],[Url],[FechaNacimiento],[Domicilio]) VALUES(@Nombre,@Apellido,@Email,@Telefono,@Url,@FechaNacimiento,@Domicilio); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, cliente.Url);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, cliente.FechaNacimiento);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, cliente.Domicilio);
                cliente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return cliente;
        }

        public List<Cliente> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre],[Apellido],[Email],[Telefono],[Url],[FechaNacimiento],[Domicilio] FROM Cliente ";

            List<Cliente> result = new List<Cliente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cliente cliente = LoadCliente(dr);
                        result.Add(cliente);
                    }
                }
            }
            return result;
        }

        public Cliente ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre],[Apellido],[Email],[Telefono],[Url],[FechaNacimiento],[Domicilio] FROM Cliente WHERE [Id]=@Id ";
            Cliente cliente = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cliente = LoadCliente(dr);
                    }
                }
            }
            return cliente;
        }

        public void Update(Cliente cliente)
        {
            const string SQL_STATEMENT = "UPDATE Cliente SET [Nombre]= @Nombre,[Apellido] = @Apellido,[Email] = @Email,[Telefono] = @Telefono,[Url] = @Url,[FechaNacimiento] = @FechaNacimiento,[Domicilio] = @Domicilio WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, cliente.Id);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, cliente.Url);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, cliente.FechaNacimiento);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, cliente.Domicilio);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cliente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Cliente LoadCliente(IDataReader dr)
        {
            Cliente cliente = new Cliente();
            cliente.Id = GetDataValue<int>(dr, "Id");
            cliente.Nombre = GetDataValue<string>(dr, "Nombre");
            cliente.Apellido = GetDataValue<string>(dr, "Apellido");
            cliente.Email = GetDataValue<string>(dr, "Email");
            cliente.Telefono = GetDataValue<string>(dr, "Telefono");
            cliente.Url = GetDataValue<string>(dr, "Url");
            cliente.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            cliente.Domicilio = GetDataValue<string>(dr, "Domicilio");

            return cliente;
        }
    }
}

