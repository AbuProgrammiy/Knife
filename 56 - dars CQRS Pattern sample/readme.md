## CQRS pattern Sample
### Steplar:
#### 1: Layerlar tashkil etish
#### 2: Entity
#### 3: Abstractions --> IApplicationDbContext
#### 4: Percictanse  --> ApplicationDbContext
#### 5: UseCases --> Themes --> Commands 
####                            Queries  
####                            Handlers --> QueryHandler
####                                         CommandHandler     
#### 6: Application --> DependencyInection
#### 8: Infrastructure --> DependencyInection
#### 9: Migrations
#### 10: Controllers 
#### 11: Run)
####
## Muhim:
### Dastur tog'ri ishlashi uchun: Application --> MediatR, MediatR.Extensions.Microsoft.DependencyInjection 11.0.0 versiyasi kochirilishi kerak!