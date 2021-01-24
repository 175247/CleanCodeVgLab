describe("Tests that all add-buttons increases ingredients", () => {
  it('Tests that you can increase the amount of Skinka', () => {
    cy.visit('http://localhost');
    cy.get('#Skinka-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#Skinka-anchor-increase').click()
    .get('#Skinka-label-stock').contains(currentStock+1);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Skinka&actionPerformed=addIngredients');
    })
  })

  it('Tests that you can increase the amount of Kebab', () => {
    cy.visit('http://localhost');
    cy.get('#Kebab-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#Kebab-anchor-increase').click()
    .get('#Kebab-label-stock').contains(currentStock+1);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Kebab&actionPerformed=addIngredients');
    })
  })
})
