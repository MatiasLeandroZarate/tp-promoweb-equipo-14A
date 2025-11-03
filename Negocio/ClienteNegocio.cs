using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ListarCLI()
        {
            List<Cliente> lista = new List<Cliente>();

            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT id, Documento, Nombre, Apellido , Email, Direccion , Ciudad , CP  FROM Clientes");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.DNI = (string)datos.Lector["Documento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.CP = (string)datos.Lector["CP"];


                    lista.Add(aux);
                }
                datos.cerrarLector();

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        public void agregar(Cliente nuevo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {

                datos.setearQuery("insert into Clientes values (@Documento,@Nombre,@Apellido,@Email,@Direccion,@Ciudad,@CP)");
                datos.setearParametro("@Documento",nuevo.DNI);
                datos.setearParametro("@Nombre ", nuevo.Nombre);
                datos.setearParametro("@Apellido" ,nuevo.Apellido);
                datos.setearParametro("@Email",nuevo.Email);
                datos.setearParametro("@Direccion",nuevo.Direccion);
                datos.setearParametro("@Ciudad",nuevo.Ciudad);
                datos.setearParametro("@CP" ,nuevo.CP);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void modificar(Cliente modificar)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("UPDATE Clientes SET Documento = @Documento, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, CP = @CP WHERE Id = @Id");
                datos.setearParametro("@Documento", modificar.DNI);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Apellido", modificar.Apellido);
                datos.setearParametro("@Email", modificar.Email);
                datos.setearParametro("@Direccion", modificar.Direccion);
                datos.setearParametro("@Ciudad", modificar.Ciudad);
                datos.setearParametro("@CP", modificar.CP);
                datos.setearParametro("@Id", modificar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
