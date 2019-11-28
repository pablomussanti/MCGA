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
    public partial class CitaDAC : DataAccessComponent, IRepository<Cita>
    {
        public Cita Create(Cita Cita)
        {
            const string SQL_STATEMENT = "INSERT INTO Cita ([Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate]) VALUES(@Fecha,@MedicoId,@PacienteId,@SalaId,@TipoServicioId,@Estado,@CreatedBy,@CreatedDate); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, Cita.Fecha);
                db.AddInParameter(cmd, "@MedicoId", DbType.AnsiString, Cita.MedicoId);
                db.AddInParameter(cmd, "@PacienteId", DbType.AnsiString, Cita.PacienteId);
                db.AddInParameter(cmd, "@SalaId", DbType.AnsiString, Cita.SalaId);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, Cita.TipoServicioId);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, Cita.Estado);
                db.AddInParameter(cmd, "@CreatedBy", DbType.AnsiString, Cita.CreatedBy);
                db.AddInParameter(cmd, "@CreatedDate", DbType.AnsiString, Cita.CreatedDate);
                Cita.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Cita;
        }



        public List<Cita> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id],[Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado] FROM Cita ";

            List<Cita> result = new List<Cita>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cita Cita = loadcita(dr);
                        result.Add(Cita);
                    }
                }
            }
            return result;
        }

        public List<Cita> Readcompleto()
        {
            const string SQL_STATEMENT = "SELECT [Id],[Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate], [ChangedBy], [ChangedDate],[DeletedBy],[DeletedDate],[Deleted] FROM Cita ";

            List<Cita> result = new List<Cita>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cita Cita = loadcitacompleta(dr);
                        result.Add(Cita);
                    }
                }
            }
            return result;
        }

        public Cita ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate], [ChangedBy], [ChangedDate],[DeletedBy],[DeletedDate],[Deleted] FROM Cita WHERE [Id]=@Id ";
            Cita Cita = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Cita = loadcita(dr);
                    }
                }
            }
            return Cita;
        }

        public void Update(Cita Cita)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Fecha]= @Fecha,[MedicoId] = @MedicoId,[PacienteId] = @PacienteId,[SalaId] = @SalaId,[TipoServicioId] = @TipoServicioId,[Estado] = @Estado,[CreatedBy] = @CreatedBy,[CreatedDate] = @CreatedDate,[ChangedBy] = @ChangedBy,[ChangedDate] = @ChangedDate,[DeletedBy] = @DeletedBy,[DeletedDate] = @DeletedDate,[Deleted] = @Deleted WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.AnsiString, Cita.Id);
                db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, Cita.Fecha);
                db.AddInParameter(cmd, "@MedicoId", DbType.AnsiString, Cita.MedicoId);
                db.AddInParameter(cmd, "@PacienteId", DbType.AnsiString, Cita.PacienteId);
                db.AddInParameter(cmd, "@SalaId", DbType.AnsiString, Cita.SalaId);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, Cita.TipoServicioId);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, Cita.Estado);
                db.AddInParameter(cmd, "@CreatedBy", DbType.AnsiString, Cita.CreatedBy);
                db.AddInParameter(cmd, "@CreatedDate", DbType.AnsiString, Cita.CreatedDate);
                db.AddInParameter(cmd, "@ChangedBy", DbType.AnsiString, Cita.ChangedBy);
                db.AddInParameter(cmd, "@ChangedDate", DbType.AnsiString, Cita.ChangedDate);
                db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, Cita.ChangedBy);
                db.AddInParameter(cmd, "@DeletedDate", DbType.AnsiString, Cita.DeletedDate);
                db.AddInParameter(cmd, "@Deleted", DbType.AnsiString, Cita.Deleted);
                db.ExecuteNonQuery(cmd);
            }
        }


        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cita WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }


        private Cita loadcita(IDataReader dr)
        {
            Cita Cita = new Cita();
            Cita.Id = GetDataValue<int>(dr, "Id");
            Cita.Estado = GetDataValue<string>(dr, "Estado");
            Cita.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            Cita.MedicoId = GetDataValue<int>(dr, "MedicoId");
            Cita.PacienteId = GetDataValue<int>(dr, "PacienteId");
            Cita.SalaId = GetDataValue<int>(dr, "SalaId");
            Cita.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            return Cita;
        }

        private Cita loadcitacompleta(IDataReader dr)
        {
            Cita Cita = new Cita();
            Cita.Id = GetDataValue<int>(dr, "Id");
            Cita.ChangedBy = GetDataValue<string>(dr, "ChangedBy");
            Cita.ChangedDate = GetDataValue<DateTime>(dr, "ChangedDate");
            Cita.CreatedBy = GetDataValue<string>(dr, "CreatedBy");
            Cita.CreatedDate = GetDataValue<DateTime>(dr, "CreatedDate");
            Cita.DeleteBy = GetDataValue<string>(dr, "DeletedBy");
            Cita.Deleted = GetDataValue<Boolean>(dr, "Deleted");
            Cita.DeletedDate = GetDataValue<DateTime>(dr, "DeletedDate");
            Cita.Estado = GetDataValue<string>(dr, "Estado");
            Cita.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            Cita.MedicoId = GetDataValue<int>(dr, "MedicoId");
            Cita.PacienteId = GetDataValue<int>(dr, "PacienteId");
            Cita.SalaId = GetDataValue<int>(dr, "SalaId");
            Cita.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            return Cita;
        }
    }
}
