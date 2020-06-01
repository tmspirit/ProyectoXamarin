using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoXamarin.Repositories
{
    public class RepositoryMotores
    {
        private String url;
        private MediaTypeWithQualityHeaderValue header;
        public RepositoryMotores()
        {
            this.url = "https://apicrudmotoresier.azurewebsites.net";
            //this.url = "https://localhost:44352/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(data, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }

        private async Task<T> CallApi<T>(String request, String token)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(data, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }

        private async Task<int> CallPostApi<T>(String request, String token, T item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                String json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        private async Task<int> CallPostApi<T>(String request, T item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                String json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        private async Task<int> CallPutApi<T>(String request, String token, T item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                String json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        #region Productos
        public async Task<int> RegistrarCompra(Carrito carrito, String token)
        {
            String request = "/api/Clientes/RegistraCompra";
            int result = await this.CallPostApi<Carrito>(request, token, carrito);
            return result;
        }

        public async Task<int> SetProducto(Productos producto, String token)
        {
            int result;
            String request = "/api/Productos";
            result = await this.CallPostApi<Productos>(request, token, producto);
            return result;
        }

        public async Task<Productos> GetProducto(int idproducto)
        {
            String request = "/api/Productos/GetProducto/" + idproducto;
            Productos producto = await this.CallApi<Productos>(request);
            return producto;
        }

        public async Task<int> EditarProducto(Productos producto, String token)
        {
            String request = "/api/Productos";
            int result = await CallPutApi<Productos>(request, token, producto);
            return result;
        }

        public async Task<List<Productos>> GetProductos()
        {
            String request = "/api/Productos";
            List<Productos> productos = await this.CallApi<List<Productos>>(request);
            return productos;
        }

        public async Task<int> SetComentario(int productoId, string coment, int masterCommentId, string token)
        {
            string request = "/api/Productos/SetComentarios";
            Comentario comentario = new Comentario();
            comentario.IdProducto = productoId;
            comentario.Comment = coment;
            comentario.FechaComentario = DateTime.Now;
            comentario.IdMasterComment = masterCommentId;
            int response = await this.CallPostApi<Comentario>(request, token, comentario);
            return response;
        }

        public async Task<List<Comentario>> GetComentarios(int productoId)
        {
            String request = "/api/Productos/GetComentarios/" + productoId;
            List<Comentario> comentarios = await this.CallApi<List<Comentario>>(request);
            return comentarios;
        }

        public async Task<List<Oferta>> GetOfertasActivas()
        {
            String request = "/api/Ofertas/GetOfertasActivas";
            List<Oferta> ofertas = await this.CallApi<List<Oferta>>(request);
            return ofertas;
        }
        #endregion 

        #region Cliente
        public async Task<Clientes> FindCliente(int codcli, string token)
        {
            String request = "/api/Clientes/BuscarCliente/" + codcli;
            Clientes cliente = await this.CallApi<Clientes>(request, token);
            return cliente;
        }

        public async Task<String> GetToken(String email, String password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                LoginModel log = new LoginModel();
                log.Email = email;
                log.passwd = password;
                String json = JsonConvert.SerializeObject(log);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                String request = "/Login/Login";
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    String data = await response.Content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(data);
                    String token = jobject.GetValue("response").ToString();
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Clientes> GetPerfil(String token)
        {
            String request = "/api/clientes/perfilcliente";
            Clientes cliente = await this.CallApi<Clientes>(request, token);
            return cliente;
        }

        public async Task<int> ChangePasswd(ChangePasswdModel changePasswd, String token)
        {
            String request = "/api/Clientes/ModificarContraseña";
            int result = await this.CallPutApi<ChangePasswdModel>(request, token, changePasswd);
            return result;
        }

        public async Task<int> RegistrarCliente(Clientes cliente)
        {
            String request = "/api/Clientes/RegistrarCliente";
            int result = await this.CallPostApi<Clientes>(request, cliente);
            return result;
        }

        public async Task<List<Clientes>> GetClientes(String token)
        {
            String request = "/api/Clientes/GetClientes";
            List<Clientes> clientes = await this.CallApi<List<Clientes>>(request, token);
            return clientes;
        }

        //PUDE HABER USADO EL METODO GENERICO CallPostApi PERO BUENO..
        public async Task<int> SubirImagen(string imagencliente, string token)
        {
            String request = "/api/Clientes/ModificarImagenCliente/" + imagencliente;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                String json = JsonConvert.SerializeObject(imagencliente);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public async Task<ObservableCollection<Pedidos>> VerMisPedidos(string token)
        {
            String request = "/api/Clientes/VerMisPedidos";
            ObservableCollection<Pedidos> pedidos = await this.CallApi<ObservableCollection<Pedidos>>(request, token);
            return pedidos;
        }

        public async Task<int> CancelarPedido(int idpedido, String token)
        {
            String request = "/api/Clientes/CancelarPedido/" + idpedido;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await client.DeleteAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
        #endregion
    }
}