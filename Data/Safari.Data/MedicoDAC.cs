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
    public partial class MedicoDAC : DataAccessComponent, IRepository<Medico>
    {
        public Medico Create(Medico medico)
        {
            const string SQL_STATEMENT = "INSERT INTO Medico ([Nombre],[Apellido],[Email],[Telefono],[TipoMatricula],[FechaNacimiento],[NumeroMatricula],[Especialidad]) VALUES(@Nombre,@Apellido,@Email,@Telefono,@TipoMatricula,@FechaNacimiento,@NumeroMatricula,@Especialidad); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, medico.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, medico.Apellido);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, medico.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, medico.Telefono);
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, medico.TipoMatricula);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, medico.FechaNacimiento);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.AnsiString, medico.NumeroMatricula);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, medico.Especialidad);
                medico.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return medico;
        }

        public List<Medico> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre],[Apellido],[Email],[Telefono],[TipoMatricula],[FechaNacimiento],[NumeroMatricula],[Especialidad] FROM Medico ";

            List<Medico> result = new List<Medico>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Medico medico = LoadMedico(dr);
                        result.Add(medico);
                    }
                }
            }
            return result;
        }

        public Medico ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre],[Apellido],[Email],[Telefono],[TipoMatricula],[FechaNacimiento],[NumeroMatricula],[Especialidad] FROM Medico WHERE [Id]=@Id ";
            Medico medico = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        medico = LoadMedico(dr);
                    }
                }
            }
            return medico;
        }

        public void Update(Medico medico)
        {
            const string SQL_STATEMENT = "UPDATE Medico SET [Nombre]= @Nombre,[Apellido] = @Apellido,[Email] = @Email,[Telefono] = @Telefono,[TipoMatricula] = @TipoMatricula,[FechaNacimiento] = @FechaNacimiento,[NumeroMatricula] = @NumeroMatricula,[Especialidad] = @Especialidad WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, medico.Id);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, medico.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, medico.Apellido);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, medico.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, medico.Telefono);
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, medico.TipoMatricula);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, medico.FechaNacimiento);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.AnsiString, medico.NumeroMatricula);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, medico.Especialidad);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Medico WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Medico LoadMedico(IDataReader dr)
        {
            Medico medico = new Medico();
            medico.Id = GetDataValue<int>(dr, "Id");
            medico.Nombre = GetDataValue<string>(dr, "Nombre");
            medico.Apellido = GetDataValue<string>(dr, "Apellido");
            medico.Email = GetDataValue<string>(dr, "Email");
            medico.Telefono = GetDataValue<string>(dr, "Telefono");
            medico.TipoMatricula = GetDataValue<string>(dr, "TipoMatricula");
            medico.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            medico.NumeroMatricula = GetDataValue<int>(dr, "NumeroMatricula");
            medico.Especialidad = GetDataValue<string>(dr, "Especialidad");

            return medico;
        }
    }
}

