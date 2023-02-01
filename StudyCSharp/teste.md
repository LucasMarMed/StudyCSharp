#print_groups.sh

A seguinte linha de comando irá mostrar a lista de grupos aos quais o usuário especificado na variável de ambiente FT_USER pertence, separados por vírgulas sem espaços:
```
$ groups $FT_USER | tr " " "," 
```
Output
```
group1,group2,group3 
```
Aqui, o comando groups é usado para obter a lista de grupos aos quais o usuário pertence. 

Em seguida, o comando tr é usado para substituir os espaços por vírgulas na saída.
  
#find_sh

A seguinte linha de comando irá procurar, na pasta atual e em todas as suas subpastas, todos os arquivos cujos nomes terminam com .sh e exibirá somente seus nomes sem o .sh:
```
Code>~/ $ find . -name "*.sh" -print | sed "s/.sh$//" 
``` 
Output
``` 
“./script1 
./folder/script2 
./folder/subfolder/script3” 
```
Aqui, o comando find é usado para procurar arquivos com nomes que terminam com .sh na pasta atual e em todas as suas subpastas. 
A opção -name "*.sh" especifica o padrão de nome de arquivo a ser procurado. 
A opção -print exibe o nome do caminho completo do arquivo encontrado. 
Em seguida, o comando sed é usado para remover a extensão .sh do nome do arquivo exibido.
  
#count_files

A seguinte linha de comando irá mostrar o número de arquivos e pastas na pasta atual e em todas as suas subpastas, incluindo o ponto (.) da pasta inicial:
```
Code>~/ $ find . -type f -o -type d | wc -l 
```
Output
```
“42” 
```
Aqui, o comando find é usado para procurar todos os arquivos (-type f) e pastas (-type d) na pasta atual e em todas as suas subpastas (./). 
A opção -o é usada para combinar os resultados da pesquisa por arquivos e pastas. 
Em seguida, o comando wc é usado para contar o número de linhas na saída, o que representa o número de arquivos e pastas encontrados.
  
#MAC

A seguinte linha de comando irá mostrar os endereços MAC da máquina:
```
Code>~/ $ ifconfig | grep -o -E '([[:xdigit:]]{1,2}:){5}[[:xdigit:]]{1,2}' 
```
Output
``` 
“00:11:22:33:44:55 
66:77:88:99:aa:bb “
```
Aqui, o comando ifconfig é usado para exibir as informações de configuração de rede da máquina. 
Em seguida, o comando grep é usado para procurar o padrão de endereço MAC na saída (([[:xdigit:]]{1,2}:){5}[[:xdigit:]]{1,2}). 
A opção -o é usada para exibir somente as correspondências encontradas e não o contexto de linha inteiro. 
A opção -E é usada para habilitar a expressão regular estendida.
  
#"\?$*’MaRViN’*$?\"

Para criar um arquivo com o nome especificado e o conteúdo "42", você pode usar o seguinte comando no shell:
```
Code>~/ echo "42" > "\?\$*'MaRViN'\*\$?\""
```
Em seguida, você pode verificar o conteúdo do arquivo com o comando: ```Code>~/ cat "\?\$*'MaRViN'\*\$?\"" ```

Output
```
42
```
  
#Skip 

A seguinte linha de comando exibirá o resultado do ls -l de duas linhas por vez, a partir da primeira:
```
Code>~/ ls -l | awk 'NR%2==1' 
```
Aqui, o comando ls -l é usado para exibir a listagem detalhada dos arquivos e pastas na pasta atual. 

Em seguida, o comando awk é usado para processar a saída e exibir somente as linhas cujo número de linha (NR) é ímpar.
  
#r_dwssap

A seguinte linha de comando exibirá o output do cat /etc/passwd com as condições especificadas:
```
Code>~/ cat /etc/passwd | grep -v "^#" | awk 'NR%2==0' | awk -F: '{print $1}' | awk '{print $1}' | rev | sort -r | awk -v line1="$FT_LINE1" -v line2="$FT_LINE2" 'NR >= line1 && NR <= line2 {printf $0", "} END {print ".."}' 
```
Aqui, o comando cat /etc/passwd é usado para exibir o conteúdo do arquivo /etc/passwd. 
O comando grep -v "^#" é usado para remover as linhas que começam com o caractere "#" (comentários). 
Em seguida, o comando awk 'NR%2==0' é usado para exibir somente as linhas cujo número de linha (NR) é par. 
O comando awk -F: '{print $1}' é usado para imprimir apenas a primeira parte de cada linha, que é o nome de usuário. 
O comando awk '{print $1}' é usado para imprimir apenas a primeira parte de cada linha (nome de usuário). 
O comando rev é usado para inverter cada nome de usuário. O comando sort -r é usado para classificar os nomes de usuário em ordem alfabética inversa. 
Finalmente, o comando awk -v line1="$FT_LINE1" -v line2="$FT_LINE2" 'NR >= line1 && NR <= line2 {printf $0", "} END {print ".."}' é usado para exibir os nomes de usuário entre as linhas FT_LINE1 e FT_LINE2 (inclusive), separados por vírgulas e terminando com "..".
