namespace Store.Service.DTOs
{
    public class PagedBaseResponseDto<T>
    {
        public int TotalRegister { get; private set; }
        public List<T> Data { get; private set; }

        public PagedBaseResponseDto(int totalRegister, List<T> data)
        {
            TotalRegister = totalRegister;
            Data = data;
        }
    }
}