<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

 <xsl:template match="/">
	<html>
	<body>
	
	<h1>Companie prestare servicii la domiciliu</h1>
	<h2><xsl:text>Bucuresti</xsl:text></h2>
	
		
		<xsl:for-each select="campionate/campionat/grupa">
		<p>Grupa <xsl:value-of select="@Nume_Grupa"/></p>
		<xsl:text>Meciuri: </xsl:text>
		<table border="1">
			<tr bgcolor="#E4DEE3">
              <th style="text-align:center;width:15%">Echipa</th>
              <th style="text-align:center;width:15%">Echipa de urgenta</th>
              <th style="text-align:center;width:15%">Scor</th>
              <th style="text-align:center">Persoana de contact</th>
			  <th style="text-align:center">Adresa</th>
			</tr>
		  
		<tr>
			<xsl:for-each select="meci[@Numar_Meci='1']/echipa">
				<td><xsl:value-of select="nume_echipa"/></td>
			</xsl:for-each>
			<xsl:for-each select="meci[@Numar_Meci='1']">
				<td><xsl:value-of select="data_assign/@val"/></td>
				<td><xsl:value-of select="persoana_de_contact/nume_persoana_de_contact"/></td>
				<td><xsl:value-of select="locatie/adresa"/></td>
			</xsl:for-each>
		</tr> 
		
		<tr>
			<xsl:for-each select="meci[@Numar_Meci='2']/echipa">
				<td><xsl:value-of select="nume_echipa"/></td>
			</xsl:for-each>
			<xsl:for-each select="meci[@Numar_Meci='2']">
        <td>
          <xsl:value-of select="data_assign/@val"/>
        </td>
        <td>
          <xsl:value-of select="persoana_de_contact/nume_persoana_de_contact"/>
        </td>
        <td>
          <xsl:value-of select="locatie/adresa"/>
        </td>
			</xsl:for-each>
	    </tr>
		
		<tr>
			<xsl:for-each select="meci[@Numar_Meci='3']/echipa">
				<td><xsl:value-of select="nume_echipa"/></td>
			</xsl:for-each>
			<xsl:for-each select="meci[@Numar_Meci='3']">
        <td>
          <xsl:value-of select="data_assign/@val"/>
        </td>
        <td>
          <xsl:value-of select="persoana_de_contact/nume_persoana_de_contact"/>
        </td>
        <td>
          <xsl:value-of select="locatie/adresa"/>
        </td>
			</xsl:for-each>
	    </tr>
		
		<tr>
			<xsl:for-each select="meci[@Numar_Meci='4']/echipa">
				<td><xsl:value-of select="nume_echipa"/></td>
			</xsl:for-each>
			<xsl:for-each select="meci[@Numar_Meci='4']">
        <td>
          <xsl:value-of select="data_assign/@val"/>
        </td>
        <td>
          <xsl:value-of select="persoana_de_contact/nume_persoana_de_contact"/>
        </td>
        <td>
          <xsl:value-of select="locatie/adresa"/>
        </td>
			</xsl:for-each>
	    </tr>
		</table>
		
		<p>Echipe: </p>
			<xsl:for-each select="meci[@Numar_Meci='1']/echipa">
			<xsl:text>Nume Echipa : </xsl:text>
				<xsl:value-of select="nume_echipa"/>
				<table border="1">
                    <tr bgcolor="#ccccff" style="width:100%">
                      <th style="width:200;text-align:left">Nume Jucator</th>
                      <th style="width:20%;text-align:left">Numar</th>
                      <th style="width:20%;text-align:left">Pozitie in teren</th>
                      
                    </tr>
				
				<xsl:for-each select="jucator">
				<tr>
				 <td><xsl:value-of select="nume_jucator"/></td>
				 <td><xsl:value-of select="numar"/></td>
				 <td><xsl:value-of select="pozitie"/></td>
				</tr>
				</xsl:for-each>
				</table>
				<p></p>
			</xsl:for-each>	
			
			<xsl:for-each select="meci[@Numar_Meci='2']/echipa">
			<xsl:text>Nume Echipa : </xsl:text>
				<xsl:value-of select="nume_echipa"/>
				<table border="1">
                    <tr bgcolor="#ccccff" style="width:100%">
                      <th style="width:200;text-align:left">Nume Jucator</th>
                      <th style="width:20%;text-align:left">Numar</th>
                      <th style="width:20%;text-align:left">Pozitie in teren</th>
                      
                    </tr>
				
				<xsl:for-each select="jucator">
				<tr>
				 <td><xsl:value-of select="nume_jucator"/></td>
				 <td><xsl:value-of select="numar"/></td>
				 <td><xsl:value-of select="pozitie"/></td>
				</tr>
				</xsl:for-each>
				</table>
				<p></p>
			</xsl:for-each>	
		
		</xsl:for-each>
		
	</body>
	</html>
 </xsl:template> 

</xsl:stylesheet>
