using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_final_de_Facturacion.BLL;
using Proyecto_final_de_Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_de_Facturacion.BLL.Tests
{
    [TestClass()]
    public class RepositoryBaseTests
    {
        [TestMethod()]
        public void RepositoryBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            Usuario usuario = new Usuario();
            usuario.IDUsuario = 1;
            usuario.Cuenta = "Danny";
            usuario.Clave = "1234";
            usuario.Nombre = "Danny Bernard";
            usuario.Pocision = true;
            RepositoryBase<Usuario> repository = new RepositoryBase<Usuario>(new DAL.Contexto());
            Assert.IsTrue(repository.Guardar(usuario));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}