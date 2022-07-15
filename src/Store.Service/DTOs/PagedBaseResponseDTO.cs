namespace Store.Service.DTOs
{
    public class PagedBaseResponseDTO<T>
    {
        public int TotalRegister { get; private set; }
        public List<T> Data { get; private set; }

        public PagedBaseResponseDTO(int totalRegister, List<T> data)
        {
            TotalRegister = totalRegister;
            Data = data;
        }
    }
}