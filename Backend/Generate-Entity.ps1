param(
    [string]$EntityName
)

New-Item -ItemType Directory -Force -Path "Core\Models"
New-Item -ItemType Directory -Force -Path "Core\IGateways"
New-Item -ItemType Directory -Force -Path "Core\UseCases\Abstractions"
New-Item -ItemType Directory -Force -Path "Infrastructure\Gateways"
New-Item -ItemType Directory -Force -Path "Api\EndPoints"

New-Item -ItemType File -Force -Path "Core\Models\$EntityName.cs"
New-Item -ItemType File -Force -Path "Core\IGateways\I$($EntityName)Gateway.cs"
New-Item -ItemType File -Force -Path "Core\UseCases\Abstractions\$($EntityName)UseCases.cs"
New-Item -ItemType File -Force -Path "Infrastructure\Gateways\$($EntityName)Gateway.cs"
New-Item -ItemType File -Force -Path "Api\EndPoints\$($EntityName)Routes.cs"