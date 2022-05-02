using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using mvctarea.Models;
using Microsoft.AspNetCore.Http;

namespace MvcMovie.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly amisoftbdpruebaContext _context;

        public TipoDocumentoController(amisoftbdpruebaContext context)
        {
            _context = context;
        }
        // 
        // GET: /INDEX/

        public IActionResult Index()
        {
            IEnumerable<TipoDocumento> colTipoDocumentos = _context.TipoDocumentos.Where(X=>X.Estado == true);
            return View(colTipoDocumentos);
        }
        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }
        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoDocumento tipoDocumento)
        {
             
                try
                {
                    if (ModelState.IsValid)
                    {
                        _context.TipoDocumentos.Add(tipoDocumento);
                        tipoDocumento.Estado = true;
                        
                        _context.SaveChanges();
                        TempData["ResultOk"] = "Recorded added succesfully";
                        
                    }  
                    return RedirectToAction("Index");                    
                }
                catch
                {
                    return View();
                }           
        }
        //GET EDIT
        public IActionResult Edit(uint id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var tipodocumentofromdb = _context.TipoDocumentos.Find(id);

            VMTipoDocumento objVMTipoDocumento =  new VMTipoDocumento();

            objVMTipoDocumento.Id = tipodocumentofromdb.Id;
            objVMTipoDocumento.Nombre = tipodocumentofromdb.Nombre;
            objVMTipoDocumento.Descripcion = tipodocumentofromdb.Descripcion;
            objVMTipoDocumento.UpdatedAt = tipodocumentofromdb.UpdatedAt;

            if (tipodocumentofromdb == null)
            {
                return NotFound();
            }
            return View(objVMTipoDocumento);
        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VMTipoDocumento vmtipoDocumento)
        {            
            try
            {
                
                TipoDocumento objTipoDocumento =  new TipoDocumento();

                objTipoDocumento.Id = vmtipoDocumento.Id;
                objTipoDocumento.Nombre = vmtipoDocumento.Nombre;
                objTipoDocumento.Descripcion = vmtipoDocumento.Descripcion;
                objTipoDocumento.UpdatedAt = vmtipoDocumento.UpdatedAt;
                objTipoDocumento.Estado = vmtipoDocumento.Estado;
            

            _context.TipoDocumentos.Update(objTipoDocumento);

            
           // objTipoDocumento.Estado=true;

            _context.SaveChanges();
            TempData["ResultOk"] = "Data updated succesfully";                    
            return RedirectToAction("Index");
            }
            catch 
            {                
                return View();
            }
        }

        //GET DELETE

        public IActionResult Delete(uint id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var tipodocumentofromdb = _context.TipoDocumentos.Find(id);
            if (tipodocumentofromdb == null)
            {
                return NotFound();
            }
            return View(tipodocumentofromdb); 
        }
        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(uint? id)
        {   
            var tipodocumentofromdb = _context.TipoDocumentos.Find(id);   
                 
            try
            {
                if (tipodocumentofromdb == null)
                {
                    return NotFound();
                } 
                tipodocumentofromdb.Estado = false;
                _context.TipoDocumentos.Remove(tipodocumentofromdb);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data deleted succesfully";
                return RedirectToAction("Index");
            }
            catch 
            {                
                return View();
            }
        }        
    }
}