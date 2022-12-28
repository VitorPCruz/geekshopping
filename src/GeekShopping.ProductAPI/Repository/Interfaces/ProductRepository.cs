using AutoMapper;
using GeekShopping.ProductAPI.ApplicationContexts;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIDbContext _context;
        private IMapper _mapper;

        public ProductRepository(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVO> FindById(long id)
        {
            return _mapper.Map<ProductVO>(
                await _context.Products.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            return _mapper.Map<IEnumerable<ProductVO>>(
                await _context.Products.ToListAsync());
        }

        public async Task<ProductVO> Create(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            // TODO: Refatorar o retorno de CREATE para ProductVO recebido como parâmetro
            return _mapper.Map<ProductVO>(product); ;
        }

        public async Task<ProductVO> Update(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);
            _context.Products.Update(product);
           
            await _context.SaveChangesAsync();
            // TODO: Refatorar o retorno de UPDATE para ProductVO recebido como parâmetro
            return _mapper.Map<ProductVO>(product); ;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
