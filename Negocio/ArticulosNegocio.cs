using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> ListarART()
        {
            List<Articulos> lista = new List<Articulos>();
            List<Imagenes> imagenes = new List<Imagenes>();

            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearStoreProcedure("storeListarIMA");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    
                    aux.Id = (int)datos.Lector["Id"];
                    //aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    //aux.idmarca.DescripcionMarcas = (string)datos.Lector["Marca"];
                    //aux.idcategoria.DescripcionCategoria = (string)datos.Lector["Categoria"];

                    //aux.Precio = (decimal)datos.Lector["Precio"];

                    

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


    }
}
