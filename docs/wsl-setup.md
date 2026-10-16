# dotfiles — Arch Linux / WSL2 (`Arch-Work`)

Entorno de desarrollo minimalista gestionado con [chezmoi](https://chezmoi.io).

## Máquina nueva

```bash
sudo pacman -S --needed chezmoi git
chezmoi init --apply <TU_REMOTE_GIT>      # clona en ~/.local/share/chezmoi y aplica
~/.local/share/chezmoi/bootstrap.sh        # instala paquetes, runtimes, shell
```

`bootstrap.sh` es idempotente: detecta lo instalado, agrega solo lo que falta
y vuelve a aplicar los dotfiles. Se puede re-ejecutar cuando quieras.

Después: completar `~/.gitconfig.local` (identidad git, **no versionada**) y
abrir `nvim` una vez para que LazyVim termine de sincronizar.

## Herramientas

| Herramienta | Rol |
|---|---|
| Fish     | shell interactivo |
| Starship | prompt |
| tmux     | sesiones persistentes |
| mise     | runtimes (Node, Python) |
| zoxide   | navegación (`z`) |
| fzf      | fuzzy finder |
| ripgrep  | búsqueda de contenido (`rg`) |
| fd       | búsqueda de archivos |
| bat      | visualización de archivos |
| eza      | listado moderno |
| micro    | editor rápido |
| Neovim   | editor avanzado |
| LazyVim  | distribución IDE para Neovim |
| chezmoi  | dotfiles |

Bash sigue disponible para scripts.

## Workspace

```
~/projects/{experiments,personal}    repos activos (filesystem Linux)
~/windows-documents -> /mnt/c/Users/psh/Documents
```

Desde Windows: `\\wsl.localhost\Arch-Work\home\martin\projects`
Desde WSL:     `explorer.exe .`

No guardar repos activos en `/mnt/c/...` — el I/O cruzando el límite WSL/Windows
es varias veces más lento.

## Actualización

```bash
sudo pacman -Syu          # sistema (nunca upgrades parciales)
mise upgrade              # runtimes
nvim +Lazy sync +qa       # plugins Neovim; luego `chezmoi add ~/.config/nvim/lazy-lock.json`
chezmoi update            # trae el remote y aplica
```

## chezmoi

```bash
chezmoi edit ~/.config/fish/config.fish   # editar el archivo fuente
chezmoi diff                              # ver qué cambiaría en $HOME
chezmoi apply                             # aplicar
chezmoi add ~/.config/algo                # incorporar un archivo existente
chezmoi re-add                            # re-absorber cambios hechos en $HOME
chezmoi cd                                # entrar al repo
git add -A && git commit -m "..."         # versionar
```

## No versionado

Claves SSH, API keys, credenciales de Claude/Codex, tokens, cookies, historial de
shell, caches, `node_modules`, plugins descargados por LazyVim
(`~/.local/share/nvim/lazy`) y `~/.gitconfig.local`.
