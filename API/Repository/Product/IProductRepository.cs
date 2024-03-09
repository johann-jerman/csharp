using API.DTO.Product;
using Entity;

namespace API.Repository.Product
{
    public interface IProductRepository
    {
        IEnumerable<Products> Get();
        Products GetById(int id);
        Products Create(ProductDTO product);
        Products Update(ProductDTO product, int id);
        void Delete(int id);
    }
}
