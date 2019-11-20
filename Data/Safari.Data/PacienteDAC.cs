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
    public partial class PacienteDAC : DataAccessComponent, IRepository<Paciente>
    {
        public Paciente Create(Paciente paciente)
        {
            const string SQL_STATEMENT = "INSERT INTO Paciente ([Nombre],[FechaNacimiento],[Observacion],[ClienteId],[EspecieId]) VALUES(@Nombre,@FechaNacimiento,@Observacion,@ClienteId,@EspecieId); SELECT SCOPE_IDENTITY();";
            try
            {
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                    db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, paciente.FechaNacimiento);
                    db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                    db.AddInParameter(cmd, "@ClienteId", DbType.AnsiString, paciente.ClienteId);
                    db.AddInParameter(cmd, "@EspecieId", DbType.AnsiString, paciente.EspecieId);
                    paciente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return paciente;

        }

        public List<Paciente> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id],[Nombre],[FechaNacimiento],[Observacion],[ClienteId],[EspecieId] FROM Paciente ";

            List<Paciente> result = new List<Paciente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Paciente paciente = LoadPaciente(dr);
                        result.Add(paciente);
                    }
                }
            }
            return result;
        }

        public Paciente ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre],[FechaNacimiento],[Observacion],[ClienteId],[EspecieId] FROM Paciente WHERE [Id]=@Id ";
            Paciente paciente = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        paciente = LoadPaciente(dr);
                    }
                }
            }
            return paciente;
        }

        public void Update(Paciente paciente)
        {
            const string SQL_STATEMENT = "UPDATE Paciente SET [Nombre]= @Nombre,[FechaNacimiento] = @FechaNacimiento,[Observacion] = @Observacion,[ClienteId] = @ClienteId,[EspecieId] = @EspecieId WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, paciente.FechaNacimiento);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                db.AddInParameter(cmd, "@ClienteId", DbType.AnsiString, paciente.ClienteId);
                db.AddInParameter(cmd, "@EspecieId", DbType.AnsiString, paciente.EspecieId);
                db.AddInParameter(cmd, "@Id", DbType.AnsiString, paciente.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Paciente WHERE [Id]= @Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.AnsiString, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Paciente LoadPaciente(IDataReader dr)
        {
            Paciente paciente = new Paciente();
            paciente.Id = GetDataValue<int>(dr, "Id");
            paciente.Nombre = GetDataValue<string>(dr, "Nombre");
            paciente.Observacion = GetDataValue<string>(dr, "Observacion");
            paciente.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            paciente.ClienteId = GetDataValue<int>(dr, "ClienteId");
            paciente.EspecieId = GetDataValue<int>(dr, "EspecieId");
            return paciente;
        }
    }
}
