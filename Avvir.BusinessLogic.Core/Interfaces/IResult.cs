namespace Avvir.BusinessLogic.Interfaces

{
    public interface IResult
    {
        string Message { get; set; }

        int Code { get; set; }
    }
}
