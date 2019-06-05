function mergeup {param($s, $t) git checkout -f $t; git rebase origin/$t; git merge $s }

After that you can go:

> mergeup v3.4 v3.5 
> git push origin v3.5