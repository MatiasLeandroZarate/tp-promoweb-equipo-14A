﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenesNegocio
    {
        public List<Imagenes> Listar()
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("select Id, IdArticulo, UrlImagen from Imagenes");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagenes aux = new Imagenes();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    lista.Add(aux);
                }
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
        public void compararID(int id)
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("select Id, IdArticulo, UrlImagen from Imagenes where IdArticulo = " + id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagenes aux = new Imagenes();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    lista.Add(aux);
                }
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
