// Esther e Cleber estão fazendo pair programming,para definir uma consulta LINQ a uma coleção de dados de Pessoas.
// A fonte de dados que eles estão usando é um List<Pessoa> em memória.
// Opções que retornam uma Pessoa com base no email informado (que é único por pessoa).

#1° Alternativa 
            
Pessoa? ConsultaCliente(List<Pessoa> _pessoas, string _email)
{
    return _pessoas.Where(x => x.Email.Equals(_email)).FirstOrDefault();
}


#2° Alternativa (SQL)

Pessoa? ConsultaCliente(List<Pessoa> _pessoas, string _email)
{
    return (from pessoa in _pessoas
            where pessoa.Email == _email
            select pessoa).FirstOrDefault();

}