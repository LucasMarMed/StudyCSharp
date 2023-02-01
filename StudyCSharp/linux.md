#Z

Criando Arquivo. Podemos usar os seguintes comandos:
```
cat
echo
nano
vi
vim
```

#testShell00

Alerar permissoes -->  ```chmod [numero da permissao] [nome arquivo] ```

Alterar timestamp --> ```touch [-t] AAAAMMDDhhmm [nome arquivo]```

Alterar tamanho do arquivo --> 

#SSH

Gerar nova Hash --> ```ssh-keygen```

Enter 3x para gerar perfil local ou preencher com email git e senha.

Copiar o ssh.pub (publico) e adicionar ao perfil

#Git_commit
```
git log -5 --pretty=format:"%h"
```

#gitignore
```
git ls-files -i --exclude-standard
```
```git ls-files -other -i --exclude-standard```

#diff
```
patch -o b a sw.diff
```

#clean
```
find . -type f -name "*~" -o -name "#*" -o -name "*#" -print -delet
```

#ft_magic
```
cat `41 string 42 42 file` > ft_magic
```
