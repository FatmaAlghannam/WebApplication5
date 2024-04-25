namespace WebApplication5.Models
    //update the api and its called the contract so they dont see every thing(id, name , manger) in the post man 
    //always create a new class for response and request so the naming or new thing is formed 
{
    public class BankBranchResponse
    {
        public string LocationName { get; set; }
        public string LocationURL { get; set; }
    }
}
