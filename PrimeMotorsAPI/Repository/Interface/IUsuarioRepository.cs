using PrimeMotorsAPI.Models;
 using PrimeMotorsAPI.Models.User;
 
 namespace PrimeMotorsAPI.Repository.Interface.User;
 
 public interface IUsuarioRepository
 {
     Task<Usuario?> ObterPorEmailAsync(string email);
     
     Task AdicionarAsync(Usuario usuario);
     
     Task SalvarAlteracoesAsync();
 }