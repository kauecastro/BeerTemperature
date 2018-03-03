# BeerTemperature

Para quem gosta de cervejas, esta é a sua API ! :)

Esta API permite você cadastrar cervejas que você curte, com os tipos e temperaturas, com a finalidade de obter dados quando você precisar.

##<b>Endpoints</b>
 
*Cadastrar um produto: 

http://<DOMAIN>/Product/CreateProduct?beerName=NAME&typeName=NAME
  
*Ler produtos  
  
http://<DOMAIN>/Product/ReadProducts?beerName=NAME
    
Alterar Produtos 
    
http://<DOMAIN>/Product/UpdateProduct?id=<ID>beerName=NAME&typeName=NAME

Deletar Produtos:

http://<DOMAIN>/Product/DeleteProduct?beerName=NAME

Pegar o a temperatura minima de um produto

http://<DOMAIN>/Product/GetMinTemperature?beerName=NAME

##<b>TypeName </b>
Type name é a categoria da cerveja. 
Para o metodos de Alterar produtos, o TypeName não é obrigatório, a não ser que vc queira alterar a categoria do produto.
*Ultilize como base esta lista:

* Weissbier	
* Pilsens	
* Weizenbier	
* Red ale	
* India pale ale
* IPA	
* Dunkel	
* Imperial Stouts	
* Brown ale

##<b>beerName </b>
O beerName é o nome do produto. 
Para o metodos de Alterar produtos, o beerName não é obrigatório, a não ser que vc queira alterar o nome do produto.

##<b>Acesso ao banco de dados. </b>
* Endpoint: beers.cog1sg4hvu7z.us-west-2.rds.amazonaws.com.
* User: kaue
* Password: kaue12345



