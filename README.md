# svatky-adresa-info-mcp-dotnet
MCP server for svatky.adresa.info

## Usage with Claude for Desktop
```json
// ~/Library/Application Support/Claude/claude_desktop_config.json
{
  "mcpServers": {
    "Info.Adresa.Svatky.Mcp": {
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "/ABSOLUTE/PATH/TO/svatky-adresa-info-mcp-dotnet",
        "--no-build"
      ]
    }
  }
}
```
