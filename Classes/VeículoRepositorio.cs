using System;
using System.Collections.Generic;
using DIO.Veiculos.Interfaces;

namespace DIO.Veiculos
{
	public class VeiculosRepositorio : IRepositorio<Veiculos>
	{
        private List<Veiculos> listaVeiculos = new List<Veiculos>();
		public void Atualiza(int id, Veiculos objeto)
		{
			listaVeiculos[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaVeiculos[id].Excluir();
		}

		public void Insere(Veiculos objeto)
		{
			listaVeiculos.Add(objeto);
		}

		public List<Veiculos> Lista()
		{
			return listaVeiculos;
		}

		public int ProximoId()
		{
			return listaVeiculos.Count;
		}

		public Veiculos RetornaPorId(int id)
		{
			return listaVeiculos[id];
		}
	}
}