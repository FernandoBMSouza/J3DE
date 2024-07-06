# J3DE
Repositório para armazenar os exercicios de reforco da materia de programacao de jogos 3d com engines

# CONTEUDO
+ Os mundos novos estou usando um logica que separa as matrizes e passa varias multiplicando no metodo draw, dessa forma consigo organizar melhor a ordem que cada operacao vai ser realizada. Isso e importante pra conseguir guardar informacoes de escala, posicao e angulo do objeto ou composicao, nos mundos antigos estou usando somente uma matriz world e dessa forma perco o controle sendo obrigado a fazer todas as atualizacoes dentro do metodo update, os mundos novos trazem uma complexidade a mais, o uso de uma auxWorld, ela e util nas composicoes para criar outras modificacoes numa matriz que ja foi modificada, dando mais liberdade para diferentes combinacoes das matrizes
+ Provas, sao as provas que ja vi e tentei replicar, ainda nao coloquei esse sistema que usei nos mundos novos nela, mas pretendo atualizar posteriormente
+ Optei por nao sobreescrever os mundos antigos, pois a logica deles e bem mais simples e podem ser uteis para fazer algo rapido durante a prova, mas pretendo usar a logica nova a partir de agora
+ Os mundos auxiliares, sao projetos bem simples que foram exemplos dados em aula para aprender uma funcionalidade espeifica por exemplo: colisao 

# MELHORIAS

+ Helicopter World
1. A posicao em que o helicoptero para esta hardcoded, preciso melhorar isso, puxar a posicao do predio para fazer o pouso
2. Criar um sistema de troca de camera com varios angulos (sempre que apertar a seta pro lado muda a camera)
    2.1 - usar array de cameras
    2.2 - usar uma camera sa que muda para varias posicoes pre-setadas (pode ser um array de posicoes)

+ Minecraft World
1. Falta aplicar textura
2. Falta colocar a camera acoplada ao player
3. Falta colisao
4. Falta o shader vermelho ao colidir com zombie
5. Falta checagem de limites do chao para andar e para instanciar eles num local que tenha chao, por enquanto esta hardcoded (acho que na aula de colisao vai ter alguma dica boa sobre como puxar o size dos shapes que criei)

+ Proximo Mundo

# Ordem Ideal das Transformacoes (altere para obter outros resultados):
- Scale
- Rotation
- Translation