using Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class PostosBusiness
    {
        private readonly Context _contexto;
        public PostosBusiness ()
        {
            _contexto = new Context();
        }

        public List<PostoCombustivel> BuscarPostosMaisBaratos()
        {
            if (_contexto.PostoCombustivel.Any())
            {
                var gasComum = _contexto.PostoCombustivel.Where(x => x.CombustivelId == 1).OrderBy(x => x.Preco).FirstOrDefault();
                var gasAdit = _contexto.PostoCombustivel.Where(x => x.CombustivelId == 2).OrderBy(x => x.Preco).FirstOrDefault();
                var etanolComum = _contexto.PostoCombustivel.Where(x => x.CombustivelId == 3).OrderBy(x => x.Preco).FirstOrDefault();
                var etanolAdit = _contexto.PostoCombustivel.Where(x => x.CombustivelId == 4).OrderBy(x => x.Preco).FirstOrDefault();

                return new List<PostoCombustivel> {
                    gasComum,
                    gasAdit,
                    etanolComum,
                    etanolAdit
                };
            }
            return null;
        }
        public List<Posto> BuscarTodosPostos()
        {
            return _contexto.Posto.ToList();
        }
        
        public void EditarPosto(int PostoId, string Nome, decimal gasComum, decimal gasAdit, decimal etanolComum, decimal etanolAdit, decimal latitude, decimal longitude)
        {
            var posto = _contexto.Posto.SingleOrDefault(x => x.PostoId == PostoId);

            posto.Nome = Nome;
            posto.PostoCombustivel.ElementAt(0).Preco = gasComum;
            posto.PostoCombustivel.ElementAt(1).Preco = gasAdit;
            posto.PostoCombustivel.ElementAt(2).Preco = etanolComum;
            posto.PostoCombustivel.ElementAt(3).Preco = etanolAdit;

            posto.Latitude = latitude;
            posto.Longitude = longitude;
            
            _contexto.SaveChanges();
        }
        public void ExcluirPosto(int PostoId)
        {
            var posto = _contexto.Posto.SingleOrDefault(x => x.PostoId == PostoId);
            var postoCombutivel = _contexto.PostoCombustivel.Where(x => x.PostoId == PostoId);
            posto.PostoCombustivel.Clear();
            _contexto.PostoCombustivel.RemoveRange(postoCombutivel);
            _contexto.Posto.Remove(posto);
            _contexto.SaveChanges();
        }
        public void CriarPosto(string Nome, decimal gasComum, decimal gasAdit, decimal etanolComum, decimal etanolAdit, decimal latitude, decimal longitude)
        {

            var novoPosto = new Posto
            {
                Nome = Nome,
                DataInclusao = DateTime.Now,
                Latitude = latitude,
                Longitude = longitude
            };

            var novoGasComum = new PostoCombustivel
            {
                Preco = gasComum,
                CombustivelId = 1
            };
            var novoGasAdit = new PostoCombustivel
            {
                Preco = gasAdit,
                CombustivelId = 2
            };
            var novoEtanolComum = new PostoCombustivel
            {
                Preco = etanolComum,
                CombustivelId = 3
            };
            var novoEtanolAdit = new PostoCombustivel
            {
                Preco = etanolAdit,
                CombustivelId = 4
            };
            novoPosto.PostoCombustivel.Add(novoGasComum);
            novoPosto.PostoCombustivel.Add(novoGasAdit);
            novoPosto.PostoCombustivel.Add(novoEtanolComum);
            novoPosto.PostoCombustivel.Add(novoEtanolAdit);
            _contexto.Posto.Add(novoPosto);
            _contexto.SaveChanges();
        }
        public Posto BuscarPostoPorId(int PostoId)
        {
            return _contexto.Posto.SingleOrDefault(x => x.PostoId == PostoId);
        }
    }
}
