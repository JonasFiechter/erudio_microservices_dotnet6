using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace GeekShopping.ProductAPI.Repository
{
    class ProducRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        ProducRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }
        public async Task<ProductVO> FindById(long id)
        {
            Product product = 
            await _context.Products.Where(
                p => p.Id == id
                ).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Create(ProductVO productVO)
        {
            Product product = _mapper.Map<Product>(productVO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return productVO;
        }
        public async Task<ProductVO> Update(ProductVO productVO)
        {
            Product product = _mapper.Map<Product>(productVO);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return productVO;
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(
                p => p.Id == id
                ).FirstOrDefaultAsync();
                if (product == null) return false;
                _context.Products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}