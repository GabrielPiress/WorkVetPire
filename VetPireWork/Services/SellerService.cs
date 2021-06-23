using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Data;
using VetPireWork.Models;
using VetPireWork.Models.Enums;
using Microsoft.EntityFrameworkCore;
using VetPireWork.Services.Exceptions;

namespace VetPireWork.Services
{
    public class SellerService
    {
        private readonly VetPireWorkContext _context;

        public SellerService(VetPireWorkContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            //Include faz parte do eager Loading carregar outros objetos associados ao objeto principal
            var listSeller = _context.Seller.Include(ob => ob.Department).ToList(); //acessa a fonte de dados do Seller e faz o ToList();
            return listSeller;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            //Include faz parte do eager Loading carregar outros objetos associados ao objeto principal
            var listSeller = await _context.Seller.Include(ob => ob.Department).ToListAsync(); //acessa a fonte de dados do Seller e faz o ToList();
            return listSeller;
        }

        public void Create(Seller seller)
        {
            seller.CreationDate = DateTime.Now;
            seller.LastChangeDate = DateTime.Now;
            seller.Active = EActive.Active;
            
           _context.Add(seller);
           _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var obj = _context.Seller.Find();
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e) //é feito isso para tratar o tipo de erro do banco na camada de serviço respeitando a arquitetura mvc
            {
                throw new DbConcurrencyException(e.Message);
            }
        
        }
    }
}
