# Typescript

These settings apply only when `--typescript` is specified on the command line.

```yaml
package-name: "@unmango/proxmox-ve"
generate-metadata: true
disable-async-iterators: false
# Supposed to default to false, doesn't seem to
add-credentials: false
project-folder: $(output-folder)/typescript
output-folder: $(project-folder)/generated
clear-output-folder: true
```
