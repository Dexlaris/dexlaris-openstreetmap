

# Dexlaris Core Persistence SDK

A .NET library for OpenStreetMap (OSM) integration. Dexlaris.OpenStreetMap supports geocoding (address/place queries) and reverse geocoding (coordinate-based lookups) using OSM's Nominatim API. Ideal for .NET mapping and geolocation apps.

## Installation

1. Install via NuGet:
   ```
   dotnet add package Dexlaris.OpenStreetMap
   ```
2. Add to your .NET project:

## Prerequisites
- .NET 8.0 or later
- Visual Studio 2022 or compatible IDE
- NuGet package manager

## Setup
1. Clone the repository:
   ```
   git clone https://github.com/Dexlaris/dexlaris-openstreetmap
   cd dexlaris-openstreetmap
   ```
2. Build the solution:
   ```
   dotnet build
   ```
3. Run tests:
   ```
   dotnet test
   ```

## Contributing
We welcome contributions! Follow these guidelines to contribute to `dexlaris-openstreetmap`.

### Branching Strategy
- **main**: Stable, production-ready code. Only updated via merged pull requests.
- **feature/***: For new features (e.g., `feature/add-email-validation`).
- **bugfix/***: For bug fixes (e.g., `bugfix/fix-json-deserialization`).
- **hotfix/***: For urgent fixes to `main` (e.g., `hotfix/patch-crypto`).
- **release/***: For preparing releases (e.g., `release/v1.0.1`).

Create a branch:
```
git checkout -b feature/your-feature-name
```

### Commit Message Template
Use clear, consistent commit messages following this format:
```
<type>(<scope>): <short description>
<BLANK LINE>
<optional detailed description>
```
- **Types**:
    - `feat`: New feature.
    - `fix`: Bug fix.
    - `docs`: Documentation changes.
    - `test`: Adding or updating tests.
    - `refactor`: Code refactoring without functional changes.
    - `chore`: Maintenance tasks (e.g., updating dependencies).
- **Scope**: Component or area (e.g., `email`, `json`, `crypto`, `extensions`, `exceptions`).
- **Short Description**: Concise summary (50 chars or less).
- **Examples**:
  ```
  feat(email): add Email class with recipient support
  
  Implements Email and Recipient domain entities for email sending.
  ```
  ```
  fix(json): handle null input in Deserialize method
  
  Prevents NullReferenceException when input is null.
  ```
  ```
  docs(readme): update contributing guidelines
  ```

### Commit Workflow
1. Make changes in your feature/bugfix branch.
2. Stage changes:
   ```
   git add .
   ```
3. Commit with a descriptive message:
   ```
   git commit -m "feat(extensions): add string placeholder replacement"
   ```
4. Push to GitHub:
   ```
   git push origin feature/your-feature-name
   ```
5. Create a pull request (PR) to `main` via GitHub UI.
    - Include a clear PR title (e.g., `Add string placeholder extension`).
    - Describe changes and reference any issues (e.g., `Closes #123`).

### Packge deployment
```bash
git tag 1.0.1
git push origin 1.0.1
# Publish from tag on Github
```

### Consume Packages
```bash
# create PAT for your user on github

# Add nuget soruce on your machine
dotnet nuget add source \
--name ORG_NAME \
--username YOUR-USERNAME \
--password xxxxx \
--store-password-in-clear-text \
https://nuget.pkg.github.com/ORG_NAME/index.json

# Create nuget.config in your project
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
        <add key="ORG_NAME" value="https://nuget.pkg.github.com/ORG_NAME/index.json" />
    </packageSources>
</configuration>
```

### Pull Request Guidelines
- Ensure tests pass (`dotnet test`).
- Update documentation if needed (e.g., `README.md`).
- Keep PRs focused on a single feature or fix.
- Squash commits if they’re minor or incremental.

### Code Style
- Follow .NET coding conventions.
- Use `dotnet format` to enforce style consistency.
- Write unit tests for new features/fixes.

## License
MIT License. See [LICENSE](LICENSE) for details.

## Contact
For issues or questions, open a GitHub issue or contact Dexlaris at support@dexlaris.com.