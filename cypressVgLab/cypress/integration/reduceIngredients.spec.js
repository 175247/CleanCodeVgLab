describe("Tests that all add-buttons reduces ingredients", () => {
  it('Tests that you can reduce the amount of Ananas', () => {
    cy.visit('http://localhost');
    cy.get('#Ananas-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#Ananas-anchor-reduce').click()
    .get('#Ananas-label-stock').contains(currentStock-1);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Ananas&actionPerformed=reduceIngredients');
    })
  })

  it('Tests that you can reduce the amount of Koriander', () => {
    cy.visit('http://localhost');
    cy.get('#Koriander-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#Koriander-anchor-reduce').click()
    .get('#Koriander-label-stock').contains(currentStock-1);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Koriander&actionPerformed=reduceIngredients');
    })
  })
})
