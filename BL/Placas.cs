using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Placas
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using ()//conexion
                {
                    var query = context.Automoviles.FromSqlRaw($"PlacasGetAll").ToList;
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Placa placas = new ML.Placa();
                            placas.IdPlacas = obj.IdPlacas;
                            placas.NumeroPlacas = obj.NumeroPlacas;

                            result.Objects.Add(placas);
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
}
