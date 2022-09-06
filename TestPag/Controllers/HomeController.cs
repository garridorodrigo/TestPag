using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestPag.Models;

namespace TestPag.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFuncionarios()
        {
            using (Context contextObj = new Context())
            {
                try
                {
                    var listaFunc = contextObj.Funcionario.ToList();
                    return Json(listaFunc, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public JsonResult GetSetores()
        {
            using (Context contextObj = new Context())
            {
                try
                {
                    var listaSetor = contextObj.Setor.ToList();
                    return Json(listaSetor, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public JsonResult GetById(int id)
        {
            using (Context contextObj = new Context())
            {
                var getFuncById = contextObj.Funcionario.Include(x=> x.Cargo).Include(x=> x.Cargo.Setor).FirstOrDefault(x=> x.FuncionarioId == id);
                return Json(getFuncById, JsonRequestBehavior.AllowGet);
            }
        }

        public string AtualizarFuncionario(Funcionario funcionario) 
        {
            if(funcionario != null)
            {
                using (Context contextObj = new Context())
                {

                    Funcionario funcObj = contextObj.Funcionario.FirstOrDefault(x => x.FuncionarioId == funcionario.FuncionarioId);
                    funcObj.NomeCompleto = funcionario.NomeCompleto;
                    contextObj.SaveChanges();
                    return "Atualizado com sucesso";
                }

                }
            else
            {
                return "Invalido";
            }
        }

        public string AdicionarFuncionario(Funcionario funcionario)
        {

            if (funcionario != null)
            {
                using (Context contextObj = new Context())
                {

                    try
                    {
                        contextObj.Entry(funcionario.Cargo.Setor).State = EntityState.Unchanged;

                        //int setorId = contextObj.Setor.FirstOrDefault(x => x.SetorId == funcionario.Cargo.Setor.SetorId).SetorId;
                        //funcionario.Cargo.Setor.SetorId = setorId;
                        contextObj.Funcionario.Add(funcionario);
                        contextObj.SaveChanges();
                        return "Adicionado com sucesso";
                    }
                    catch(Exception ex) 
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                return "Invalido";
            }
        }

        public string DeletarFuncionario(int funcionarioId)
        {
            if (funcionarioId > 0)
            {
                using (Context contextObj = new Context())
                {
                    try
                    {
                        var func = contextObj.Funcionario.FirstOrDefault(x => x.FuncionarioId == funcionarioId);
                        contextObj.Funcionario.Remove(func);
                        contextObj.SaveChanges();
                        return "Deletado com sucesso";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                return "Invalido";
            }
        }
    }
}