using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySqlX.XDevAPI;
using SistemaCadastroBalanço.database;
using SistemaCadastroBalanço.database.Cadastros;



namespace ClienteController.Controllers
{

    public class ClienteController : Controller
    {
        static MyDB ClienteDB = new MyDB();
        // GET: lista de Cliente
        public ActionResult Index()
        {
            List<Clientes> clientes = ClienteDB.ListarClientes();
            return View("Lista", clientes);
        }

        // GET: Cliente/Details/3
        public ActionResult Details(string id)
        {
            Clientes cliente = ClienteDB.BuscaClientePeloId(id);

            if (cliente == null)
            {
                return RedirectToAction("Index");
            }

            return View("Details", cliente);
        }
        
        public ActionResult Criar()
        {
            return View("Criar");
        }
        // POST: Cliente/Create
        [HttpPost]
        public ActionResult criarusuario(string idCliente, string cliente, string pet, string idadepet, string cel, string observacoes)
        {
            ClienteDB.AdicionarCliente(idCliente, cliente, pet, idadepet, cel, observacoes);
            return RedirectToAction("Index");
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(string id)
        {
            Clientes cliente = ClienteDB.BuscaClientePeloId(id);
            if (cliente == null)
            {
                return RedirectToAction("Index");
            }
            return View("Edit", cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clientes clientes)
        {
            ClienteDB.AtualizarCliente(clientes);
            return RedirectToAction("Index");
        }

        // GET: Cliente/Delete/5
        public ActionResult ViewDelete(string id)
        {
            Clientes cliente = ClienteDB.BuscaClientePeloId(id);
            if (cliente == null)
            {
                return RedirectToAction("Index");
            }
            return View("Deletar", cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            ClienteDB.ExcluirCliente(id);
            return RedirectToAction("Index");
        }
    }
}
