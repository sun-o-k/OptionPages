package com.jetbrains.rider.plugins.samples.options

import com.jetbrains.rider.settings.simple.SimpleOptionsPage

class SashaPage : SimpleOptionsPage(
    name = "Pretty little page",
    pageId = "SashaPage" // Must be in sync with SamplePage.PID
) {
    override fun getId(): String {
        return "SashaPage"
    }
}