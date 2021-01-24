describe("Tests that a mass delivery increases all ingredients", () => {
  it('Tests that you can add 10 ingredients in a mass delivery to Musslor', () => {
    cy.visit('http://localhost');
    cy.get('#Musslor-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#receiveMassDelivery').click()
    .get('#Musslor-label-stock').contains(currentStock+10);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Musslor&actionPerformed=massDelivery');
    })
  })

  it('Tests that you can add 10 ingredients in a mass delivery to Champinjoner', () => {
    cy.visit('http://localhost');
    cy.get('#Champinjoner-label-stock').then(($label) => {
      let currentStock = parseInt($label.text());
    cy.get('#receiveMassDelivery').click()
    .get('#Champinjoner-label-stock').contains(currentStock+10);

    cy.request('DELETE', 'http://localhost/api/storage/ResetTests?ingredientName=Champinjoner&actionPerformed=massDelivery');
    })
  })
})
