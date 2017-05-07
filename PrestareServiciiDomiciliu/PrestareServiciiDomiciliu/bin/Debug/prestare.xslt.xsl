<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"></link>

        <!-- Optional theme -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous"></link>


      </head>
      <body>

        <h1>Companie prestare servicii la domiciliu</h1>
        <h2>
          <xsl:text>Bucuresti</xsl:text>
        </h2>


        <xsl:for-each select="planificari/planificare/grupa">
          <p>
            Nume Sectiune <xsl:value-of select="@Nume_Grupa"/>
          </p>
          <xsl:text>Activitati: </xsl:text>
          <table class="table" border="1">
            <tr bgcolor="#E4DEE3">
              <th style="text-align:center;width:15%">Echipa</th>
              <th style="text-align:center;width:15%">Echipa de urgenta</th>
              <th style="text-align:center;width:15%">Data</th>
              <th style="text-align:center">Persoana de contact</th>
              <th style="text-align:center">Adresa</th>
            </tr>

            <tr>
              <xsl:for-each select="assignment[@asg_num='1']/echipa">
                <td>
                  <xsl:value-of select="nume_echipa"/>
                </td>
              </xsl:for-each>
              <xsl:for-each select="assignment[@asg_num='1']">
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
              <xsl:for-each select="assignment[@asg_num='2']/echipa">
                <td>
                  <xsl:value-of select="nume_echipa"/>
                </td>
              </xsl:for-each>
              <xsl:for-each select="assignment[@asg_num='2']">
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
              <xsl:for-each select="assignment[@asg_num='3']/echipa">
                <td>
                  <xsl:value-of select="nume_echipa"/>
                </td>
              </xsl:for-each>
              <xsl:for-each select="assignment[@asg_num='3']">
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
              <xsl:for-each select="assignment[@asg_num='4']/echipa">
                <td>
                  <xsl:value-of select="nume_echipa"/>
                </td>
              </xsl:for-each>
              <xsl:for-each select="assignment[@asg_num='4']">
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
          <xsl:for-each select="assignment[@asg_num='1']/echipa">
            <xsl:text>Nume Echipa : </xsl:text>
            <xsl:value-of select="nume_echipa"/>
            <table class="table" border="1">
              <tr bgcolor="#ccccff" style="width:100%">
                <th style="width:200;text-align:left">Nume persoana</th>
                <th style="width:20%;text-align:left">Numar CI</th>
                <th style="width:20%;text-align:left">Grad/Pozitie</th>

              </tr>

              <xsl:for-each select="membru">
                <tr>
                  <td>
                    <xsl:value-of select="nume_membru"/>
                  </td>
                  <td>
                    <xsl:value-of select="serie_ci"/>
                  </td>
                  <td>
                    <xsl:value-of select="pozitie"/>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
            <p></p>
          </xsl:for-each>

          <xsl:for-each select="assignment[@asg_num='2']/echipa">
            <xsl:text>Nume Echipa : </xsl:text>
            <xsl:value-of select="nume_echipa"/>
            <table class="table" border="1">
              <tr bgcolor="#ccccff" style="width:100%">
                <th style="width:200;text-align:left">Nume persoana</th>
                <th style="width:20%;text-align:left">Numar CI</th>
                <th style="width:20%;text-align:left">Grad/Pozitie</th>

              </tr>

              <xsl:for-each select="membru">
                <tr>
                  <td>
                    <xsl:value-of select="nume_membru"/>
                  </td>
                  <td>
                    <xsl:value-of select="serie_ci"/>
                  </td>
                  <td>
                    <xsl:value-of select="pozitie"/>
                  </td>
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
