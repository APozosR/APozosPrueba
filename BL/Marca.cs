using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Marca
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using ()//conexion
                {
                    var query = context.Automoviles.FromSqlRaw($"MarcaGetAll").ToList;
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Marca marca = new ML.Marca();
                            marca.IdMarca = obj.IdMarca;
                            marca.Nombre = obj.Nombre;

                            result.Objects.Add(marca);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
