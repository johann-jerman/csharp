using API.DTO.Product;
using API.Repository.Product;
using Entity;

namespace API.Service.Product
{
    public class ProductService : IProductService
    {
        private ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Products> Get()
        {
            return _repository.Get();
        }

        public Products GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Products Create(ProductDTO data)
        {
            return _repository.Create(data);
        }

        public Products Update(ProductDTO data, int id)
        {
            return _repository.Update(data, id);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            return;
        }

    }
}
