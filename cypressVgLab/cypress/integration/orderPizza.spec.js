describe("Tests that you can order a margerita", () => {
  it('Tests that ordering a margerita reduces Skinka', () => {
    cy.visit('http://localhost');
    cy.get('#Skinka-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#orderPizza').click()
    .get('#Skinka-label-stock').contains(currentStock-1);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Skinka&actionPerformed=orderMargerita');
    })
  })

  it('Tests that ordering a margerita reduces Ananas', () => {
    cy.visit('http://localhost');
    cy.get('#Ananas-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#orderPizza').click()
    .get('#Ananas-label-stock').contains(currentStock-1);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Ananas&actionPerformed=orderMargerita');
    })
  })
})
