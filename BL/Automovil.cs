namespace BL
{
    public class Automovil
    {
        public static ML.Result Add(ML.Automovil auto) 
        {
            ML.Result result = new ML.Result();
            try
            {
                using ()//conexion
                {
                    var query = context.Database.FromSqlRaw($"AutomovilAdd '{auto.Modelo}','{auto.Color}',{auto.NumeroPuertas},{auto.Placa.IdPlacas},{auto.Marca.IdMarca}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage =Ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Automovil auto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using ()//conexion
                {
                    var query = context.Database.FromSqlRaw($"AutomovilUpdate {auto.IdAutomovil},'{auto.Modelo}','{auto.Color}',{auto.NumeroPuertas},{auto.Placa.NumeroPlacas},{auto.Marca.Nombre}");
                    if(query > 0)
                    {
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
        public static ML.Result Delete(int IdAutomovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using ()//conexion
                {
                    var query = context.Database.FromSqlRaw($"AutomovilDelete {IdAutomovil}");
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using ()//conexion
                {
                    var query = context.Automoviles.FromSqlRaw($"AutomovilGetAll").ToList;
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Automovil auto = new ML.Automovil();
                            auto.IdAutomovil = obj.IdAutomovil;
                            auto.Modelo = obj.Modelo;
                            auto.Color = obj.Color;
                            auto.NumeroPuertas = obj.NumeroPuertas;

                            auto.Placas = new ML.Placa();
                            auto.Placa.IdPlacas = obj.Placas.IdPlacas;

                            auto.Marca = new ML.Marca();
                            auto.Marca.IdMarca = obj.Marca.IdMarca;

                            result.Objects.Add(auto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdAutomovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using ()//conexion
                {
                    var query = context.Automoviles.FromSqlRaw($"AutomovilGetById {IdAutomovil}").AsEnumerable.FirstOrDefault;
                    if(query != null)
                    {
                        ML.Automovil auto = new ML.Automovil();
                        auto.IdAutomovil = query.IdAutomovil;
                        auto.Modelo = query.Modelo;
                        auto.Color = query.Color;
                        auto.NumeroPuertas = query.NumeroPuertas;

                        auto.Placa = new ML.Placa();
                        auto.Placa.IdPlacas = query.Placas.IdPlacas;

                        auto.Marca = new ML.Marca();
                        auto.Marca.IdMarca = query.Marca.IdMarca;

                        result.Object = auto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}