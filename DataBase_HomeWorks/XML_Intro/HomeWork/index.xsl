<?xml version="1.0"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <head>
                <title>Database Course @ Telerik Academy 2015</title>
            </head>
            <body>
                <div id="header">
                    <h1>Database XML Intro Homework</h1>
                    <h3>Some simple student data XML representation</h3>
                </div>
                <div id="content">
                        <ul>
                            <xsl:for-each select="students/student">
                                <li>
                                    <ul>
                                        <li><xsl:value-of select="facultyNumber"/></li>
                                        <li><xsl:value-of select="name"/></li>
                                        <li><xsl:value-of select="sex"/></li>
                                        <li><xsl:value-of select="birthDate"/></li>
                                        <li><xsl:value-of select="phone"/></li>
                                        <li><xsl:value-of select="email"/></li>
                                        <li><xsl:value-of select="course"/></li>
                                    </ul>
                                </li>
                            </xsl:for-each>
                        </ul>
                </div>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
