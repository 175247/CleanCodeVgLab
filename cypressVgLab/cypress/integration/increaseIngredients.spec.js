describe("Tests that all add-buttons increases ingredients"){
  it('Tests that you can increase the amount of Skinka', => (){
    cy.visit('http://localhost')
    .get('#skinka')
  })
}
