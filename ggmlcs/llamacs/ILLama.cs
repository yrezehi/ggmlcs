namespace LLamacs
{
    public interface ILLama<in T>
    {
        public void Infer(T input);
    }
}