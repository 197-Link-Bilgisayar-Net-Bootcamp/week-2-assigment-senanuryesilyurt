using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            if(product is not null)
            {
                _productDal?.Add(product);
            }
        }

        public void Delete(Product product)
        {
            if(product is not null)
            {
                _productDal?.Delete(product);
            }
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public void Update(Product product)
        {
            if(product is not null)
            {
                _productDal?.Update(product);
            }
        }
    }
}
