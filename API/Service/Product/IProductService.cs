using API.DTO.Product;
using Entity;

namespace API.Service.Product
{
    public interface IProductService
    {
        IEnumerable<Products> Get();
        Products GetById(int id);
        Products Create(ProductDTO data);
        Products Update(ProductDTO data, int id);
        void Delete(int id);
    }
}
