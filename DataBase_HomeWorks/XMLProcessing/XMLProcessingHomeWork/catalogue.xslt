<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
      <html>
        <body>
          <table border="1">
            <xsl:for-each select="catalogue/album">
            <tr>
              <td colspan="2">Album: </td>
              <td colspan="2"><xsl:value-of select="name"/></td>
            </tr>
            <tr>
              <td>Artist: </td>
              <td><xsl:value-of select="artist"/></td>
              <td>Year: </td>
              <td><xsl:value-of select="year"/></td>
            </tr>
            <tr>
              <td>Price: </td>
              <td><xsl:value-of select="price"/></td>
              <td>Producer: </td>
              <td><xsl:value-of select="producer"/></td>
            </tr>
            <tr>
              <td colspan="4">Track List</td>
            </tr>
              <xsl:for-each select="trackList/song">
            <tr>
              <td colspan="2"><xsl:value-of select="title"/></td>
              <td colspan="2">
                <xsl:value-of select="duration"/> seconds.
              </td>
            </tr>
              </xsl:for-each>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
