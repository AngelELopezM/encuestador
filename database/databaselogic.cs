using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using database.repositorios;
using database.modelos;
namespace database
{

    public class databaselogic
    {
        private SqlConnection connection;
        public databaselogic()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
             connection = new SqlConnection(connectionstring);
        }

        #region servicios a usuarios
        public int login(string usuario, string contra)
        {/*Aqui hacemos una consulta si la consulta nos devuelve algo entonces vamos a tomar el id del 
            usuario que encontramos para poder ir al menu*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contra=@contra",connection);
            command.Parameters.AddWithValue("usuario",usuario);
            command.Parameters.AddWithValue("contra",contra);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int id_usuario= (int)reader["id"];
                    connection.Close();
                    return id_usuario;
                }

            }
            connection.Close();
            return 0;
        }
        public void agregar_usuario(usuarios usuarios)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT  INTO usuario VALUES     (nombre=@nombre,apellido=@apellido,contra=@contra,usuario=@usuario, contra=@contra)", connection);
            command.Parameters.AddWithValue("@nombre", usuarios.nombre);
            command.Parameters.AddWithValue("@apellido", usuarios.apellido);
            command.Parameters.AddWithValue("@usuario",usuarios.usuario);
            command.Parameters.AddWithValue("@contra", usuarios.contra);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public bool validar_noombre_usuario(string usuario)
        {
            /*Aqui validamos que el nombre de usuario que vayamos a agregar no este en uso,
             si nos devuelve un valor verdadero entonces significa que el usuario ya esta en uso*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario",connection);
            command.Parameters.AddWithValue("@usuario",usuario);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    connection.Close();
                    return true;
                }
            }

            connection.Close();
            return false;
        }
        #endregion

        #region servicios encuestas
        public DataTable Getencuestas(int id)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT id_encuesta, nombre_encuesta FROM encuestas "+
                "WHERE id_usuario =@id",connection);
            command.Parameters.AddWithValue("id",id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;

        } 
        public int get_ultimo_id_enc()
        {
            /*Con esto se supone que intentamos llevar un control de el numero de la encuesta para de esta
             manera poder relacionar las preguntas, no utilizamos un identity sino que directamente vamos a tomar
             el numero de la ultima encuesta y lo vamos a sumar aqui para poder obtener el numero de la siguiente*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT MAX(id_encuesta) from encuestas", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int numero = reader.GetInt32(0);
                    connection.Close();
                    return numero + 1;
                }
            }
            connection.Close();
            return 0;
                    
                

            
            
            
        }
        public void agregar_preg_nueva_encuesta(repositorio_encuestas preguntas)
        {/*Aqui se va a ejecutar un stored procedure que va a insertar las preguntas a la tabla de encuestas temporal
            una a una y tambien al mismo tiempo va a actualizar el nombre de la encuesta cada vez que se entre una nueva
            pregunta solo en caso de que en el transcurso de la creacion de la encuesta el usuario quiera cambiar el nombre
            de la encuesta*/
            connection.Open();
            SqlCommand command = new SqlCommand("EXEC sp_agregar_pregunta @id_usuario,@id_encuesta,@nombre_encuesta,@id_pregunta,"+
                "@pregunta,@respuesta1,@respuesta2,@respuesta3, @respuesta4", connection);
            command.Parameters.AddWithValue("@id_usuario",preguntas.id_usuario);
            command.Parameters.AddWithValue("@id_encuesta",preguntas.id_encuesta);
            command.Parameters.AddWithValue("@nombre_encuesta",preguntas.nombre_encuesta);
            command.Parameters.AddWithValue("@id_pregunta",preguntas.id_pregunta);
            command.Parameters.AddWithValue("@pregunta",preguntas.pregunta);
            command.Parameters.AddWithValue("@respuesta1",preguntas.respuesta1);
            command.Parameters.AddWithValue("@respuesta2",preguntas.respuesta2);
            command.Parameters.AddWithValue("@respuesta3",preguntas.respuesta3);
            command.Parameters.AddWithValue("@respuesta4",preguntas.respuesta4);

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void guardar_encuesta()
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("INSERT INTO encuestas SELECT * FROM encuestas_temporal",connection))
            {
                command.ExecuteNonQuery();
            }
            connection.Close();

        }

        public void limpiar_encuesta_temporal()
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("TRUNCATE TABLE encuestas_temporal",connection))
            {
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void eliminar_encuesta(int id, int id_usuario) {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE encuestas WHERE id_encuesta = @id and id_usuario = @id_usuario", connection);
            command.Parameters.AddWithValue("@id",id);
            command.Parameters.AddWithValue("@id_usuario",id_usuario);
            command.ExecuteNonQuery();

            connection.Close();
        }
        public void editar_pregunta(int id, preguntas pregunta)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE encuestas SET pregunta=@pregunta, "+
                "r_1 = @r1,r_2=@r2,r_3=@r3,r_4=@r4 FROM encuestas WHERE id_encuesta = @id and id_pregunta =@id_pregunta", connection);

            command.Parameters.AddWithValue("@id_pregunta", pregunta.id_pregunta);
            command.Parameters.AddWithValue("@pregunta", pregunta.pregunta);
            command.Parameters.AddWithValue("@r1", pregunta.respuesta1);
            command.Parameters.AddWithValue("@r2", pregunta.respuesta2);
            command.Parameters.AddWithValue("@r3", pregunta.respuesta3);
            command.Parameters.AddWithValue("@r4", pregunta.respuesta4);
            
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void eliminar_preguntas(int id,int id_pregunta)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE encuestas WHERE id_encuesta = @id and id_pregunta =@id_pregunta", connection);
            command.Parameters.AddWithValue("@id",id);
            command.Parameters.AddWithValue("id_pregunta",id_pregunta);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable Get_preguntas(int id)
        {
            
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT id_pregunta, pregunta, r_1,r_2,r_3,r_4 "+
                " FROM encuestas WHERE id_encuesta = @id ", connection);

            command.Parameters.AddWithValue("id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public int get_last_preg_id(int id_encuesta, int id_usuario)
        {/*Aqui agregamos buscamos el numero de la ultima pregunta y le sumamos uno para poder
            tener una continuidad*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT MAX(id_pregunta) FROM encuestas where "+
                " id_encuesta = @id_encuesta and id_usuario = @id_usuario",connection);
            command.Parameters.AddWithValue("@id_encuesta",id_encuesta);
            command.Parameters.AddWithValue("@id_usuario",id_usuario);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            connection.Close();
            return id;
        }
        public void agregar_pregunta_extra(int id_encuesta,string nombre_enc, int id_usuario,preguntas preguntas)
        {
           connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO encuestas VALUES (@id_usuario,  @id_encuesta,@nombre_encu,@id_pregunta,@pregunta,@r_1, @r_2,  @r_3,  @r_4) ", connection);

            command.Parameters.AddWithValue("@nombre_encu", nombre_enc);
            command.Parameters.AddWithValue("@id_encuesta", id_encuesta);
            command.Parameters.AddWithValue("@id_usuario", id_usuario);
            command.Parameters.AddWithValue("@id_pregunta", preguntas.id_pregunta);
            command.Parameters.AddWithValue("@pregunta", preguntas.pregunta);
            command.Parameters.AddWithValue("@r_1", preguntas.respuesta1);
            command.Parameters.AddWithValue("@r_2", preguntas.respuesta2);
            command.Parameters.AddWithValue("@r_3", preguntas.respuesta3);
            command.Parameters.AddWithValue("@r_4", preguntas.respuesta4);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public string get_nombre_encuesta(int id_encuesta)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select nombre_encuesta from encuestas where id_encuesta = @id_encuesta", connection);
            command.Parameters.AddWithValue("@id_encuesta",id_encuesta);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                string encuesta = reader.GetString(0);
                connection.Close();
                return encuesta;
            }
            
        }

        #endregion
        #region aplicacion de encuesta
        public List<preguntas> get_preguntas_para_aplicar(int id_encuesta)
        {
            /*Este metodo lo vamos a utilizar para traer todas preguntas de la encuesta que queremos
             para despues ponerlas en un list que vamos a utilizar*/
            connection.Open();

            List<preguntas> listado = new List<preguntas>();
            SqlCommand command = new SqlCommand("SELECT * FROM vw_preguntas WHERE id_encuesta = @id_encuesta ", connection);
            command.Parameters.AddWithValue("@id_encuesta", id_encuesta);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listado.Add(new preguntas
                    {
                        id_pregunta = (int)reader["id_pregunta"],
                        pregunta = reader["pregunta"].ToString(),
                        nombre_encuesta = reader["nombre_encuesta"].ToString(),
                        respuesta1 = reader["r_1"].ToString(),
                        respuesta2 = reader["r_2"].ToString(),
                        respuesta3 = reader["r_3"].ToString(),
                        respuesta4 = reader["r_4"].ToString()
                    }
                    );


                }

            }
            connection.Close();
            return listado;

        }

        public void capturar_respuesta_temporal(int id_encu,int id_encuestado, string encuestado, int id_preg, string respuesta)
        {
            /*Aqui vamos a capturar todas las preguntas que se han hecho al encuestado para que una vez
             se finalice la  encuesta podamos pasarlas al formulario permanente y si la encuesta no es completada 
             pues simplemente se borra lo que se tiene en este formulatio*/
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO respuesta_temp VALUES(@id_encuesta,@id_encuestado, " +
                "@encuestado,@id_pregunta,@respuesta)", connection);
            
            command.Parameters.AddWithValue("@id_encuesta", id_encu);
            command.Parameters.AddWithValue("@id_encuestado", id_encuestado);
            command.Parameters.AddWithValue("@encuestado", encuestado);
            command.Parameters.AddWithValue("@id_pregunta", id_preg);
            command.Parameters.AddWithValue("@respuesta", respuesta);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void limpiar_respuesta_temporal()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE respuesta_temp",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void capturar_respuestas()
        {
            /*Aqui ya es donde sometemos las respuestas de la encuesta permanentemente*/
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO respuestas SELECT * FROM respuesta_temp",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public int get_last_encuestado_id()
        {/*Aqui agregamos buscamos el numero de la ultima pregunta y le sumamos uno para poder
            tener una continuidad*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT MAX(id_encuestado) FROM respuestas", connection);
            
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            connection.Close();
            return id;
        }
        #endregion

        #region visualizar encuesta
        public DataTable get_encuestados(int id_encuesta)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT id_encuestado, encuestado FROM respuestas WHERE id_encuesta = @id", connection);
            command.Parameters.AddWithValue("@id",id_encuesta);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public DataTable get_respuestas(int id,int id_encuesta)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM vw_respuestas WHERE id_encuestado = @id and id_encuesta = @id_encuesta", connection);
            command.Parameters.AddWithValue("@id",id);
            command.Parameters.AddWithValue("@id_encuesta", id_encuesta);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        #endregion

    }
}
