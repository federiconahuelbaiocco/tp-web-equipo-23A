﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
	public class ImagenNegocio
	{
		public List<Imagen> lista(int idArticulo)
		{
			List<Imagen> lista = new List<Imagen>();
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("SELECT  I.Id, I.IdArticulo, I.ImagenUrl FROM IMAGENES I WHERE I.IdArticulo = @idArticulo");
				datos.setearParametro("@idArticulo", idArticulo);
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Imagen aux = new Imagen();

					aux.Id = (int)datos.Lector["Id"];
					aux.IdArticulo = (int)datos.Lector["IdArticulo"];
					aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

					lista.Add(aux);
				}

				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al listar imágenes para el artículo: " + idArticulo, ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
	}
}
