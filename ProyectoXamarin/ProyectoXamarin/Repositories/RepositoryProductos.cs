using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoXamarin.Repositories
{
    public class RepositoryProductos
    {
        private String url;
        private MediaTypeWithQualityHeaderValue header;
        public RepositoryProductos()
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
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
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

        public async Task<int> SetProducto(Productos producto, String token)
        {
            int result;
            String request = "/api/Productos";
            result = await this.CallPostApi<Productos>(request, token, producto);
            return result;
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
        public async Task<int> RegistrarCompra(Carrito carrito, String token)
        {
            String request = "/api/Clientes/RegistraCompra";
            int result = await this.CallPostApi<Carrito>(request, token, carrito);
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

        public async Task<int> SetComentario(Comentario comentario, String token)
        {
            String request = "/api/Productos/SetComentarios";
            int response = await this.CallPostApi<Comentario>(request, token, comentario);
            return response;
        }

        public async Task<List<Comentario>> GetComentarios(String idproducto)
        {
            String request = "/api/GetComentarios/" + idproducto;
            List<Comentario> comentarios = await this.CallApi<List<Comentario>>(request);
            return comentarios;
        }

        public async Task<List<Oferta>> GetOfertasActivas()
        {
            String request = "/api/Ofertas/GetOfertasActivas";
            List<Oferta> ofertas = await this.CallApi<List<Oferta>>(request);
            return ofertas;
        }
        #region LOGIN
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
            String request = "/api/Clientes/PerfilCliente";
            Clientes cliente = await this.CallApi<Clientes>(request, token);
            return cliente;
        }
        #endregion


    }
}